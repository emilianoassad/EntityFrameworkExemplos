# Ferramentas

- [Visual Studio 2019 Community](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&rel=16)
- [SQL Server 2019 Developer](https://go.microsoft.com/fwlink/?linkid=866662)
- [Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)

# Pacotes instalados

1. Install-Package Install-Package Microsoft.EntityFrameworkCore
2. Install-Package Install-Package Microsoft.EntityFrameworkCore.SqlServer
3. Install-Package Install-Package Microsoft.EntityFrameworkCore.Tools

# Comandos p/ Migration

1. Add-Migration NomeDaMigration //Adiciona uma nova migração
2. Remove-Migration //Remove a última migração criada
3. Update-Database //Atualiza o banco de dados com as migrações
4. Update-Database NomeDaMigracao //Atualiza o banco de dados para a migração informada
