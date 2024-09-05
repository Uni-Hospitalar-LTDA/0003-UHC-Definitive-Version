/** Para os bancos de SP, CE e PE**/
EXEC sp_rename 'Users.active', 'Status', 'COLUMN';
