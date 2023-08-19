# XZone Roleplay V

### Initial setup
1. Download Rage MP https://rage.mp/
2. Open the RAGE MP launcher and join a server, this should generate a `server-files` folder in your RAGE MP installation folder.
3. Create a new folder in your `Local Disk (C:)` drive called `XZRPV`.
   - Move the `server-files` folder from `C:\RAGEMP` into this new `XZRPV` folder.
4. Open this `server-files` folder from `C:\XZRPV\server-files`.
   - Update the `conf.json` file and set the `csharp` attribute from `disabled` to `enabled`.
   - Inside the `dotnet` folder open the `settings.xml` file.
   - Update `<acl_enabled>true</acl_enabled>` from `true` to `false`.
   - Add `<resource src="XZRPV" />`.

### Visual Studio dev environment installation
1. Open `XZRPV.csproj` file with Visual Studio.
2. Duplicate the `.env.example` file and rename it to `.env`.
   - You don't need to modify this file, only if your MYSQL credentials are different.
3. (OPTIONAL) Open the `XZRPV.csproj` file and update output paths, if you followed the steps above you shouldn't have to worry about this step.
4. Compile the solution.

### Setup Database using Docker
1. Download docker desktop https://www.docker.com/products/docker-desktop/
   - You can also use docker-engine if you'd prefer, but I recommend docker desktop if you are new to docker.
3. Enable Hyper-v and virtualization, you can also do this using WSL 2 (I recommend using WSL 2).
4. In PowerShell, execute the following command `docker-compose up -d` and wait until it's finished running.
   - ![image](https://github.com/XZRPV/XZRPV/assets/45730487/ccbbbb99-29b8-4e2c-bf8e-3761e917dd25)
5. Go into the XZRPV solution in Visual Studio.
   - Open the NuGet package manager console from `Tools > NuGet Package Manager > Package Manager Console`.
   - In the Package Manager Console enter the command `Update-Database`, this will run all the Database migrations and will add the tables to your Database.
   - ![image](https://github.com/XZRPV/XZRPV/assets/45730487/d8e030ac-4c11-417d-ba2a-4dc120b66dc0)
6. The Migrations should have been successful.
7. We recommend you use an MYSQL IDE to ensure the tables migrated successfully, we recommend https://tableplus.com/ as it's a light-weight IDE.

### Final setup for the server to run the XZRPV gamemode
1. After compiling the project, go into this path `C:\XZRPV\server-files\dotnet\resources\XZRPV`.
2. Create a new `meta.xml` file and add the following:
```
<?xml version="1.0" encoding="utf-8" ?>
<meta>
  <info name="XZRPV" type="gamemode"/>
  <!-- Gamemode library -->
  <script src="netcoreapp3.1\XZRPV.dll" />
</meta>
```
