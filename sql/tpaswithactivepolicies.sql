select

   COUNT(*) as NoOfAccounts,

   IsNull(dl4.Name, 'Unassigned') as Administrator,

   dl4.FileAs, 

   dl4.MailAddress, 

   dl4.MailCity, 

   dl4.MailState, 

   dl4.MailZip,

   IsNull(dc1.FirstName, 'UW No Assigned') as UW

 

from VIEW_CtrContract XLMD 

join ReiTreaties      on XLMD.TreatyId        = ReiTreaties.ReiTreatyId 

join InsGroups        on XLMD.InsGroupId      = InsGroups.InsGroupId 

left outer join DirListings dl4  on XLMD.AdministratorId = dl4.DirListingId 

LEFT JOIN DirContacts dc1 ON XLMD.UnderwriterId = dc1.DirContactId

where ((XLMD.Status in ('BOUN', 'BIND', 'INFC')) or (XLMD.Status = 'SENT' and XLMD.StatusLevel = 'APPL')) and (XLMD.Status NOT IN ('DEAD', 'RESC', 'NOIS')) AND NOT ((((XLMD.Status = 'SENT') or (XLMD.Status = 'REQD')) and (XLMD.StatusLevel <> 'APPL')))

GROUP BY IsNull(XLMD.AdministratorId, -1), IsNull(dl4.Name, 'Unassigned'), dl4.FileAs, dl4.MailAddress, dl4.MailCity, dl4.MailState, dl4.MailZip, IsNull(dc1.FirstName, 'UW No Assigned')

order by Administrator

