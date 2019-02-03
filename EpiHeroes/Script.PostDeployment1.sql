/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
MERGE INTO Comic AS Target
USING (VALUES
		(1, 'Marvel'),
		(2, 'DC')
)
AS Source (Id, Name)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Id, Name)
VALUES (Id, Name);