update Users
set
	FirstName = @FirstName,
	LastName = @LastName,
	DateUpdated = GETDATE()
output
	INSERTED.*
where UserGuid = @UserGuid