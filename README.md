# XZone Roleplay V

### Initial setup
1. Download the latest release https://github.com/XZRPV/XZRPV/releases - make sure you download the executables and the server files.
2. Move the `XZRPV` folder you downloaded from releases into your `Local Disk (C:)` drive.
3. Unzip the Windows or Linux executable into the root of your project folder, in this case, `XZRPV`.
4. Run the server executable and ignore any errors for now.

### Visual Studio dev environment installation
1. Open `XZRPV.csproj` file with Visual Studio.
2. (OPTIONAL) Open the `XZRPV.csproj` file and update output paths, if you followed the steps above you shouldn't have to worry about this step.
3. Compile the solution.

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
6. The Migrations should have run successfully.
7. We recommend you use a MYSQL IDE to ensure the tables migrated successfully, we recommend https://tableplus.com/ as it's a light-weight IDE.

### Final setup for the server to run the XZRPV gamemode
1. After successfully compiling the project run the server executable once again.
2. Enjoy!
