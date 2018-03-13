/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Role VALUES ('Student')
INSERT INTO Role VALUES ('Professor')

INSERT INTO [User] VALUES ('admin', '1000:VjyXU7Xf9jz3dqx61BrjnY5dIvGB4EHq:2hFT0Zmlv9EnkUj0ykp+VrNHCa+b4rCY', 'Admin Professor', 0, 2)