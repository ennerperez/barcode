#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define solutions.
var solutions = new Dictionary<string, string> {
     { "./src/barcode.sln", "Any" },
};

// Define directories.
var buildDir =  Directory("../../build/" + configuration);
var outputDir =  Directory("build/" + configuration);

// Define AssemblyInfo source.
var assemblyInfoVersion = ParseAssemblyInfo("./src/.files/AssemblyInfo.Version.cs");
var assemblyInfoCommon = ParseAssemblyInfo("./src/.files/AssemblyInfo.Common.cs");

// Define version.
var elapsedSpan = new TimeSpan(DateTime.Now.Ticks - new DateTime(2001, 1, 1).Ticks);
var assemblyVersion = assemblyInfoVersion.AssemblyVersion.Replace("*", elapsedSpan.Ticks.ToString().Substring(4, 4));
var version = new System.Version(EnvironmentVariable("APPVEYOR_BUILD_VERSION") ?? Argument("version", assemblyVersion)).ToString(3);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
	CleanDirectories("./**/bin");
    CleanDirectories("./**/obj");
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    foreach (var solution in solutions)
    {
        NuGetRestore(solution.Key);
    }
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    foreach (var solution in solutions)
    {
        if (IsRunningOnWindows())
        {
            var settings = new MSBuildSettings();
			      //.WithProperty("OutDir", buildDir);
            // .WithProperty("PackageVersion", version)
            // .WithProperty("BuildSymbolsPackage", "false");
            settings.SetConfiguration(configuration);
            // Use MSBuild
            MSBuild(solution.Key, settings);
        }
        else
        {
            var settings = new XBuildSettings();
			      //.WithProperty("OutDir", buildDir);
            // .WithProperty("PackageVersion", version)
            // .WithProperty("BuildSymbolsPackage", "false");
            settings.SetConfiguration(configuration);
            // Use XBuild
            XBuild(solution.Key, settings);
        }
    }
});

Task("Build-NuGet-Packages")
    .Does(() =>
{

	var StandardId = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";
	var NETCoreId = "{9A19103F-16F7-4668-BE54-9A1E7A4F7556}";
	List<SolutionProject> projects  = null;

	foreach (var solution in solutions)
	{
		var file = ParseSolution(solution.Key);
		var items = from item in file.Projects 
					where item.Type == StandardId || item.Type == NETCoreId
					select item;
		projects = items.ToList();
	}
	
	foreach (var project in projects)
	{
		var file = new System.IO.FileInfo(project.Path.FullPath);
		var path = file.Directory;
		var nuspecs = path.GetFiles("*.nuspec");

		foreach (var nuspec in nuspecs)
		{
			Information("Using: " + nuspec.FullName);
			NuGetPackSettings nuGetPackSettings = null;
			if(System.IO.File.Exists(path.FullName + "/Properties/AssemblyInfo.cs"))
			{
				var assemblyInfo = ParseAssemblyInfo(path.FullName + "/Properties/AssemblyInfo.cs");
				nuGetPackSettings = new NuGetPackSettings()
				{
					OutputDirectory = outputDir,
					IncludeReferencedProjects = false,
					Id = assemblyInfo.Title.Replace(" ", "."),
					Title = assemblyInfo.Title,
					Version = version,
					Authors = new[] { assemblyInfoCommon.Company },
					Summary = assemblyInfo.Description,
					Copyright = assemblyInfoCommon.Copyright,
					Properties = new Dictionary<string, string>() {{ "Configuration", configuration }}
				};
			}
			else
			{
				nuGetPackSettings = new NuGetPackSettings()
				{
					OutputDirectory = outputDir,
					IncludeReferencedProjects = false,
					//Id = assemblyInfo.Title.Replace(" ", "."),
					//Title = assemblyInfo.Title,
					Version = version,
					Authors = new[] { assemblyInfoCommon.Company },
					//Summary = assemblyInfo.Description,
					Copyright = assemblyInfoCommon.Copyright,
					Properties = new Dictionary<string, string>() {{ "Configuration", configuration }}
				};
			}
			if (nuGetPackSettings != null)
			{ 
				NuGetPack(nuspec.FullName, nuGetPackSettings); 
			}
		}
	}
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    NUnit3("./src/**/bin/" + configuration + "/*.Tests.dll", new NUnit3Settings {
        NoResults = true
        });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-Unit-Tests")
	.IsDependentOn("Build-NuGet-Packages");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
