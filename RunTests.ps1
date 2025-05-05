# 1. Clear allure-results
$allureResults = ".\bin\Debug\net8.0\allure-results"
if (Test-Path $allureResults) {
    Remove-Item "$allureResults\*" -Recurse -Force
    Write-Host "Allure results directory cleared"
}

# 2. Run preconditions
dotnet test --settings nunit.preconditions.runsettings

# 3. Run main tests (if previous passed)
if ($LASTEXITCODE -eq 0) {
    dotnet test --settings nunit.main.runsettings
}
