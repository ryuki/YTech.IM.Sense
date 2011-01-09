ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [DB_IM_PARAMITA], FILENAME = '$(DefaultDataPath)$(DatabaseName).mdf', FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];

