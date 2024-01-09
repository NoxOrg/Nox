# Development

**Nox.Generator.Tasks** is a development task attached to this project for creating or updating templates. Follow these steps to modify the tasks within Nox.Generator.Tasks:

1. Make your desired changes within the **Nox.Generator.Tasks** project.
2. To ensure the changes take effect, perform the following steps:
    - Run the command `taskkill /IM "MSBuild.exe" /F` in the terminal. This command is usually sufficient to stop the build process. If needed, also execute `taskkill /IM "dotnet.exe" /F`.
3. Build the **Nox.Generator.Tasks** project.
4. Finally, build the **Cryptocash.Ui** project.

These steps ensure that any alterations made within **Nox.Generator.Tasks** are properly reflected and built before executing the **Cryptocash.Ui** project.
