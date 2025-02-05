SELECT u.username as username,
r.Name as rolename , u.*, r.*, ur.*
FROM dbo.AspNetUsers u
INNER JOIN dbo.AspNetUserRoles ur ON u.Id = ur.UserId
INNER JOIN dbo.AspNetRoles r ON ur.RoleId = r.Id;