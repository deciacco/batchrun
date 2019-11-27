select
   convert(varchar(6), effectivedate, 112) as effectivedate,
   policyholdername,
   codeplcstatus.description,
   isnull(dl4.name, 'unassigned') as administrator,
   isnull(dlp.name, 'unassigned') as producer,
   isnull(dl4.email, '') as adminemail,
   isnull(dlp.email, '') as produceremail,
   case when xlmd.administratorid = xlmd.producerid
		then 'yes'
		else 'no'
   end as adminsameprod,
   dl4.address as adminaddress, 
   dl4.city as admincity, 
   dl4.state as adminstate, 
   dl4.zip as adminzip,
   dlp.address as produceraddress, 
   dlp.city as producercity, 
   dlp.state as producerstate, 
   dlp.zip as producerzip,
   isnull(dc1.firstname, 'uw no assigned') as uw

from view_ctrcontract xlmd 

  left join dirlistings dl4  
    on xlmd.administratorid = dl4.dirlistingid

  left join dirlistings dlp
    on xlmd.producerid = dlp.dirlistingid

  left join dircontacts dc1 
    on xlmd.underwriterid = dc1.dircontactid

  join codeplcstatus
    on xlmd.status = codeplcstatus.status

where ((xlmd.status in ('boun', 'bind', 'infc')) or 
        (xlmd.status = 'sent' and xlmd.statuslevel = 'appl')) and  
        (xlmd.status not in ('dead', 'resc', 'nois')) and not 
        ((((xlmd.status = 'sent') or (xlmd.status = 'reqd')) and 
        (xlmd.statuslevel <> 'appl')))

order by policyholdername