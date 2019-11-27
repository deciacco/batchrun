select distinct
   isnull(dl4.name, 'unassigned') as prodadminname,
   isnull(dl4.email, '') as email,
   'admin+prod' as role

from view_ctrcontract xlmd 

  join dirlistings dl4  
    on xlmd.administratorid = dl4.dirlistingid

where ((xlmd.status in ('boun', 'bind', 'infc')) or 
        (xlmd.status = 'sent' and xlmd.statuslevel = 'appl')) and  
        (xlmd.status not in ('dead', 'resc', 'nois')) and not 
        ((((xlmd.status = 'sent') or (xlmd.status = 'reqd')) and 
        (xlmd.statuslevel <> 'appl'))) and
       (xlmd.administratorid = xlmd.producerid)

union

select distinct
   isnull(dlp.name, 'unassigned') as prodadminname,
   isnull(dlp.email, '') as email,
   'prod' as role

from view_ctrcontract xlmd 

  join dirlistings dlp
    on xlmd.producerid = dlp.dirlistingid

where ((xlmd.status in ('boun', 'bind', 'infc')) or 
        (xlmd.status = 'sent' and xlmd.statuslevel = 'appl')) and  
        (xlmd.status not in ('dead', 'resc', 'nois')) and not 
        ((((xlmd.status = 'sent') or (xlmd.status = 'reqd')) and 
        (xlmd.statuslevel <> 'appl'))) and 
        (producerid not in (
		select distinct administratorid
		from view_ctrcontract xlmd 
		where ((xlmd.status in ('boun', 'bind', 'infc')) or 
		        (xlmd.status = 'sent' and xlmd.statuslevel = 'appl')) and  
		        (xlmd.status not in ('dead', 'resc', 'nois')) and not 
		        ((((xlmd.status = 'sent') or (xlmd.status = 'reqd')) and 
		        (xlmd.statuslevel <> 'appl'))) and
		       (xlmd.administratorid = xlmd.producerid)

))
order by prodadminname