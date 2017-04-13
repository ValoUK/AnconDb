declare @kill_process nvarchar(50)
declare @db_name nvarchar(50)
declare @spid nvarchar(50)

DECLARE killer_cursor CURSOR FOR
select  d.name , convert (smallint, req_spid) As spid
from master.dbo.syslockinfo l, master.dbo.spt_values v, master.dbo.spt_values x, master.dbo.spt_values u, master.dbo.sysdatabases d
where   l.rsc_type = v.number and v.type = 'LR' and l.req_status = x.number and x.type = 'LS' and l.req_mode + 1 = u.number
and u.type = 'L' and l.rsc_dbid = d.dbid 
and rsc_dbid = (select top 1 dbid from master..sysdatabases where name like 'AnconProfiles');
			     
OPEN killer_cursor  
FETCH NEXT FROM killer_cursor   
INTO @db_name, @spid  
  
WHILE @@FETCH_STATUS = 0  
BEGIN  
	SET @kill_process =  'KILL ' + @spid      
	EXEC master.dbo.sp_executesql @kill_process
	PRINT 'killed spid : '+ @spid 
	FETCH NEXT FROM killer_cursor   
	INTO @db_name, @spid  
END   
CLOSE killer_cursor;  
DEALLOCATE killer_cursor; 


if exists (select * from sysdatabases where name='AnconProfiles')
	drop database AnconProfiles
go

--CREATE DATABASE Study 
--	ON PRIMARY (NAME = 'Study', FILENAME = 'C:\AnconDb\Study.mdf')
--	LOG ON (NAME = 'Study_log',  FILENAME = 'C:\AnconDb\Study.ldf')
--go