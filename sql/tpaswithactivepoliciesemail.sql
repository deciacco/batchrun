select
   count(xlmd.ctrcontractid) as noofaccounts,
   dl4.fileas,
   dl4.email,
   xlmd.policyholdername

from
	view_ctrcontract xlmd
  join reitreaties
    on xlmd.treatyid = reitreaties.reitreatyid
  join insgroups
    on xlmd.insgroupid = insgroups.insgroupid
  left outer join dirlistings dl4
    on xlmd.administratorid = dl4.dirlistingid
  left join dircontacts dc1
    on xlmd.underwriterid = dc1.dircontactid

where (
        (xlmd.status in ('boun', 'bind', 'infc')) or
        (xlmd.status = 'sent' and xlmd.statuslevel = 'appl')
       )
      and 
        (xlmd.status not in ('dead', 'resc', 'nois')) 
      and not
      (
        (
          ((xlmd.status = 'sent') or (xlmd.status = 'reqd'))
          and 
          (xlmd.statuslevel <> 'appl')
        )
      )

group by dl4.fileas, dl4.email, xlmd.policyholdername

order by dl4.fileas