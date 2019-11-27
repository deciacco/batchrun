select distinct * from 
	(select dirlistings.dirlistingid, dirlistings.status, fileas, mailaddress, mailcity, mailstate, mailzip,
		address, city, state, zip, null as lastname
		from dirlistings 
		join diradministrators on diradministrators.dirlistingid = dirlistings.dirlistingid
	union
	 	select dirlistings.dirlistingid, dirlistings.status, fileas, mailaddress, mailcity, mailstate, mailzip,
		address, city, state, zip, lastname 
	 	from dirlistings 
		join dirproducers on dirproducers.dirlistingid = dirlistings.dirlistingid
		join dircontacts on dirproducers.underwriterid = dircontacts.dircontactid) 
as christmaslist 
where status = 'actv' and address is not null
order by christmaslist.fileas

select distinct christmaslist.*, DirContacts.LastName

from (select 'a' as asdas, dirlistings.dirlistingid, dirlistings.status, fileas, mailaddress, mailcity, mailstate, mailzip,

        address, city, state, zip, dirproducers.UnderwriterId

        from dirlistings

        join diradministrators on diradministrators.dirlistingid = dirlistings.dirlistingid

        join dirproducers      on dirproducers.dirlistingid      = dirlistings.dirlistingid

    union

    select 'b' as asdas, dirlistings.dirlistingid, dirlistings.status, fileas, mailaddress, mailcity, mailstate, mailzip,

        address, city, state, zip, NULL

        from dirlistings

        join diradministrators on diradministrators.dirlistingid = dirlistings.dirlistingid

        where not exists (Select 1 FROM dirproducers WHERE dirproducers.dirlistingid = dirlistings.dirlistingid)

    union

         select 'c', dirlistings.dirlistingid, dirlistings.status, fileas, mailaddress, mailcity, mailstate, mailzip,

        address, city, state, zip, dirproducers.UnderwriterId

         from dirlistings

        join dirproducers on dirproducers.dirlistingid = dirlistings.dirlistingid

        where not exists (Select 1 FROM DirAdministrators WHERE diradministrators.dirlistingid = dirlistings.dirlistingid)

) as christmaslist

left outer join dircontacts on christmaslist.UnderwriterId = dircontacts.dircontactid

where christmaslist.status = 'actv' and christmaslist.address is not null

order by christmaslist.fileas


