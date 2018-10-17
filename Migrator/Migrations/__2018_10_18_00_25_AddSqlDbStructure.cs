namespace UniversityBoard.Migrator.Migrations
{
    using SimpleMigrations;

    [Migration(2018_10_18_00_25, "Add Sql Db Structure")]
    public class __2018_10_18_00_25_AddSqlDbStructure : Migration
    {
        protected override void Up()
        {
            this.Execute(@"-- Дамп структуры базы данных batunin_402_user
                    CREATE DATABASE IF NOT EXISTS `batunin_402_user` /*!40100 DEFAULT CHARACTER SET utf8 */;
                    USE `batunin_402_user`;


                    -- Дамп структуры для таблица batunin_402_user.AcademicDepartaments
                    CREATE TABLE IF NOT EXISTS `AcademicDepartaments` (
                        `Code` int(11) NOT NULL,
                        `Name` varchar(120) NOT NULL,
                        PRIMARY KEY (`Code`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8;

                    -- Экспортируемые данные не выделены.


                    -- Дамп структуры для таблица batunin_402_user.AcademicDisciplines
                    CREATE TABLE IF NOT EXISTS `AcademicDisciplines` (
                        `DisciplineCode` varchar(50) NOT NULL,
                        `Name` varchar(120) NOT NULL,
                        `AcademicDepartamentCode` int(11) DEFAULT NULL,
                        PRIMARY KEY (`DisciplineCode`),
                        KEY `FK_AcademicDisciplines_AcademicDepartaments` (`AcademicDepartamentCode`),
                        CONSTRAINT `FK_AcademicDisciplines_AcademicDepartaments` FOREIGN KEY (`AcademicDepartamentCode`) REFERENCES `AcademicDepartaments` (`Code`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8;

                    -- Экспортируемые данные не выделены.


                    -- Дамп структуры для таблица batunin_402_user.EducationalDirections
                    CREATE TABLE IF NOT EXISTS `EducationalDirections` (
                        `Code` varchar(50) NOT NULL,
                        `Name` varchar(80) NOT NULL,
                        PRIMARY KEY (`Code`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8;

                    -- Экспортируемые данные не выделены.


                    -- Дамп структуры для таблица batunin_402_user.Groups
                    CREATE TABLE IF NOT EXISTS `Groups` (
                        `Id` int(11) NOT NULL AUTO_INCREMENT,
                        `Number` varchar(5) NOT NULL,
                        `HeadId` int(11) DEFAULT NULL,
                        `FormationDate` date DEFAULT NULL,
                        `EducationalDirectionCode` varchar(50) DEFAULT NULL,
                        PRIMARY KEY (`Id`),
                        KEY `FK_Groups_EducationalDirections` (`EducationalDirectionCode`),
                        CONSTRAINT `FK_Groups_EducationalDirections` FOREIGN KEY (`EducationalDirectionCode`) REFERENCES `EducationalDirections` (`Code`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8;

                    -- Экспортируемые данные не выделены.


                    -- Дамп структуры для таблица batunin_402_user.Students
                    CREATE TABLE IF NOT EXISTS `Students` (
                        `Id` int(11) NOT NULL AUTO_INCREMENT,
                        `LastName` varchar(20) NOT NULL,
                        `StudentCardIssueDate` date DEFAULT NULL,
                        `FirstName` varchar(20) NOT NULL,
                        `MiddleName` varchar(20) DEFAULT NULL,
                        `Gender` tinyint(4) DEFAULT NULL COMMENT '1 - Мужской, 2 - Женский',
                        `BirthDay` date DEFAULT NULL,
                        `StudentCardNumber` int(11) DEFAULT NULL,
                        `GroupId` int(11) NOT NULL,
                        PRIMARY KEY (`Id`),
                        KEY `FK_Students_Groups` (`GroupId`),
                        CONSTRAINT `FK_Students_Groups` FOREIGN KEY (`GroupId`) REFERENCES `Groups` (`Id`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8;


                    -- Дамп структуры для таблица batunin_402_user.Attestations
                    CREATE TABLE IF NOT EXISTS `Attestations` (
                        `Id` int(11) NOT NULL AUTO_INCREMENT,
                        `Date` date NOT NULL,
                        `AcademicDisciplineCode` varchar(50) NOT NULL,
                        `GroupId` int(11) NOT NULL,
                        `HoursCount` int(11) NOT NULL,
                        `AppraisalType` int(11) NOT NULL,
                        PRIMARY KEY (`Id`),
                        KEY `FK_Attestations_Groups` (`GroupId`),
                        CONSTRAINT `FK_Attestations_Groups` FOREIGN KEY (`GroupId`) REFERENCES `Groups` (`Id`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8;

                    -- Экспортируемые данные не выделены.


                    -- Дамп структуры для таблица batunin_402_user.ExamInfos
                    CREATE TABLE IF NOT EXISTS `ExamInfos` (
                        `Id` int(11) NOT NULL AUTO_INCREMENT,
                        `AttestationId` int(11) NOT NULL DEFAULT '0',
                        `Date` date DEFAULT NULL,
                        `StudentId` int(11) NOT NULL,
                        `Score` int(11) NOT NULL,
                        `Level` int(11) DEFAULT NULL,
                        PRIMARY KEY (`Id`),
                        KEY `FK_ExamInfos_Attestations` (`AttestationId`),
                        KEY `FK_ExamInfos_Students` (`StudentId`),
                        CONSTRAINT `FK_ExamInfos_Attestations` FOREIGN KEY (`AttestationId`) REFERENCES `Attestations` (`Id`),
                        CONSTRAINT `FK_ExamInfos_Students` FOREIGN KEY (`StudentId`) REFERENCES `Students` (`Id`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8;

                    -- Экспортируемые данные не выделены.
            ");
        }

        protected override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}