select 
	
	IsNull(
		(select DirListings.Name from DirListings where DirListings.DirListingId = XLMD.AdministratorId), 
		'Unassigned'
	      ) as paName , 

	COUNT(distinct XLMD.PlcXLMDPolicyId) as NumCases, 
 
	Sum(IsNull(sp_trm.SpInitialEstAnnPremium, 0) + IsNull(PlcXLMDAgTerms.AgInitialEstAnnPremium, 0)) as TotalGrossPremium,
	'admin' as which,
	dl4.address as address, 
   	dl4.city as city, 
   	dl4.state as state, 
   	dl4.zip as zip

from VIEW_CtrContract 
	join PlcXLMDPolicies XLMD        	on VIEW_CtrContract.CtrContractId   = XLMD.PlcXLMDPolicyID 
	join ReiTreaties                 	on VIEW_CtrContract.TreatyId        = ReiTreaties.ReiTreatyId 
	left outer join InsGroups        	on VIEW_CtrContract.InsGroupId      = InsGroups.InsGroupId 
	left outer join CodePlcStatus    	on VIEW_CtrContract.Status          = CodePlcStatus.Status 
	left outer join DirListings dl1  	on VIEW_CtrContract.ProducerID      = dl1.DirListingId 
	left outer join DirListings dl2  	on VIEW_CtrContract.OfficeId        = dl2.DirListingId 
	left outer join DirContacts      	on VIEW_CtrContract.UnderwriterId   = DirContacts.DirContactId 
	left outer join DirListings dl3  	on VIEW_CtrContract.CarrierId       = dl3.DirListingId 
	left outer join DirListings dl4  	on VIEW_CtrContract.AdministratorId = dl4.DirListingId 
	left outer join CodeSic          	on InsGroups.SIC                    = CodeSic.SIC 
	left outer join PlcXLMDSpTerms sp_trm 	on sp_trm.PlcXLMDPolicyId = XLMD.PlcXLMDPolicyId 
	left outer join PlcXLMDAgTerms 		on PlcXLMDAgTerms.PlcXLMDPolicyId = XLMD.PlcXLMDPolicyId 
	left outer join (    
		select 	PlcXLMDSchedules.PlcXLMDPolicyId,      
			SUM( CASE WHEN SpRateSchedule in ('TS12', 'TS13', 'TS14') THEN SpCensus1 ELSE SpCensus1+SpCensus2+SpCensus3+SpCensus4        END) as Census    
		from PlcXLMDSchedules    
			join PlcXLMDSpRates on PlcXLMDSpRates.PlcXLMDScheduleId = PlcXLMDSchedules.PlcXLMDScheduleId    
			join PlcXLMDPolicies ON PlcXLMDPolicies.PlcXLMDPolicyId = PlcXLMDSchedules.PlcXLMDPolicyId    
		WHERE PlcXLMDSchedules.ScheduleType = 'PRIM'      
			AND PlcXLMDSpRates.EffectiveDate = PlcXLMDPolicies.EffectiveDate    
		group by PlcXLMDSchedules.PlcXLMDPolicyId  ) sp_rates on sp_rates.PlcXLMDPolicyId = XLMD.PlcXLMDPolicyId  
	LEFT OUTER JOIN (
		SELECT  PlcXLMDPolicies.PlcXLMDPolicyId,  
			SUM((PlcXLMDAcqExpenses.Percentage * DATEDIFF(MONTH, PlcXLMDAcqExpenses.EffectiveDate, DATEADD(DAY, 1, PlcXLMDAcqExpenses.ExpirationDate)) / PlcXLMDPolicies.MonthsInContract)) as SpExpensePercent,  
                   	SUM((PlcXLMDAcqExpenses.Amount * DATEDIFF(MONTH, PlcXLMDAcqExpenses.EffectiveDate, DATEADD(DAY, 1, PlcXLMDAcqExpenses.ExpirationDate)) / PlcXLMDPolicies.MonthsInContract)) as SpExpenseAmount                  
		FROM 	PlcXLMDPolicies                  
				JOIN PlcXLMDAcqExpenses ON PlcXLMDAcqExpenses.PlcXLMDpolicyId = PlcXLMDPolicies.PlcXLMDPolicyId                 
 		WHERE 	PlcXLMDAcqExpenses.CoverageType = 'SPEC' AND PlcXLMDPolicies.MonthsInContract <> 0 AND 
			PlcXLMDAcqExpenses.IsActive = 'Y' GROUP BY PlcXLMDPolicies.PlcXLMDPolicyId 
			) SpExpenses on SpExpenses.PlcXLMDPolicyId = XLMD.PlcXLMDPolicyId 
	LEFT OUTER JOIN (
		SELECT 	PlcXLMDPolicies.PlcXLMDPolicyId, 
			SUM((PlcXLMDAcqExpenses.Percentage * DATEDIFF(MONTH, PlcXLMDAcqExpenses.EffectiveDate, DATEADD(DAY, 1, PlcXLMDAcqExpenses.ExpirationDate)) / PlcXLMDPolicies.MonthsInContract)) as AgExpensePercent,                     
			SUM((PlcXLMDAcqExpenses.Amount * DATEDIFF(MONTH, PlcXLMDAcqExpenses.EffectiveDate, DATEADD(DAY, 1, PlcXLMDAcqExpenses.ExpirationDate))                        / PlcXLMDPolicies.MonthsInContract)) as AgExpenseAmount                  
		FROM 	PlcXLMDPolicies                  
				JOIN PlcXLMDAcqExpenses ON PlcXLMDAcqExpenses.PlcXLMDpolicyId = PlcXLMDPolicies.PlcXLMDPolicyId                  
		WHERE 	PlcXLMDAcqExpenses.CoverageType = 'AGGR' AND 
			PlcXLMDPolicies.MonthsInContract <> 0 AND 
			PlcXLMDAcqExpenses.IsActive = 'Y'                  
		GROUP BY PlcXLMDPolicies.PlcXLMDPolicyId                 
			) AgExpenses on AgExpenses.PlcXLMDPolicyId = XLMD.PlcXLMDPolicyId 
	LEFT OUTER JOIN (
		SELECT 	PlcXLMDPolicies.PlcXLMDPolicyId,    
			ReiXLMDTreaties.SpCarrierFeePercent as SpCARFPercentage                 
		FROM 	PlcXLMDPolicies                  
				JOIN ReiXLMDTreaties ON ReiXLMDTreaties.ReiTreatyId = PlcXLMDPolicies.TreatyId                  
		WHERE 	NOT EXISTS (
				SELECT 	1 
				FROM 	PlcXLMDAcqExpenses                                    
				WHERE	PlcXLMDAcqExpenses.PlcXLMDPolicyId = PlcXLMDPolicies.PlcXLMDPolicyId AND 
					PlcXLMDAcqExpenses.AcqExpenseType = 'CARF' AND 
					PlcXLMDAcqExpenses.CoverageType   = 'SPEC'
				   )                 
		        ) SpCARF ON SpCARF.PlcXLMDpolicyId = VIEW_CtrContract.CtrContractId 
	LEFT OUTER JOIN (
		SELECT 	PlcXLMDPolicies.PlcXLMDPolicyId,       
	               	ReiXLMDTreaties.AgCarrierFeePercent as AgCARFPercentage                  
		FROM 	PlcXLMDPolicies                  
				JOIN ReiXLMDTreaties ON ReiXLMDTreaties.ReiTreatyId = PlcXLMDPolicies.TreatyId 
                WHERE 	NOT EXISTS (
				SELECT 	1 
				FROM 	PlcXLMDAcqExpenses       
                                WHERE 	PlcXLMDAcqExpenses.PlcXLMDPolicyId = PlcXLMDPolicies.PlcXLMDPolicyId AND
					PlcXLMDAcqExpenses.AcqExpenseType = 'CARF' AND 
					PlcXLMDAcqExpenses.CoverageType   = 'AGGR'
				    )
	                 ) AgCARF ON AgCARF.PlcXLMDpolicyId = VIEW_CtrContract.CtrContractId 
	LEFT OUTER JOIN (
		SELECT	PlcXLMDPolicies.PlcXLMDPolicyId,
	                ReiXLMDTreaties.PremiumTaxPercent as PremiumTaxPercent
		 FROM 	PlcXLMDPolicies
				JOIN ReiXLMDTreaties ON ReiXLMDTreaties.ReiTreatyId = PlcXLMDPolicies.TreatyId 
                 WHERE 	NOT EXISTS (
				SELECT 	1 
				FROM 	PlcXLMDAcqExpenses
				WHERE 	PlcXLMDAcqExpenses.PlcXLMDPolicyId = PlcXLMDPolicies.PlcXLMDPolicyId AND
					PlcXLMDAcqExpenses.AcqExpenseType = 'PTAX'
		                   )
	                 ) PTAX ON PTAX.PlcXLMDpolicyId = VIEW_CtrContract.CtrContractId 
where (((VIEW_CtrContract.Status in ('BOUN', 'BIND', 'INFC')) or 
	(VIEW_CtrContract.Status = 'SENT' and VIEW_CtrContract.StatusLevel = 'APPL')) ) and 
	(XLMD.Status NOT IN ('DEAD', 'RESC', 'NOIS')) AND NOT ((((XLMD.Status = 'SENT') or 
	(XLMD.Status = 'REQD')) and (XLMD.StatusLevel <> 'APPL')))
 
Group By 
	 XLMD.AdministratorId,
	 dl4.address, 
   	 dl4.city, 
   	 dl4.state, 
   	 dl4.zip

union

select 

IsNull((select DirListings.Name from DirListings where DirListings.DirListingId = XLMD.ProducerId), 'Unassigned')      as paName , 
COUNT(distinct XLMD.PlcXLMDPolicyId) as NumCases, Sum(IsNull(sp_trm.SpInitialEstAnnPremium, 0) + IsNull(PlcXLMDAgTerms.AgInitialEstAnnPremium, 0)) as TotalGrossPremium,
'prod' as which,	
dl1.address as address, 
   	dl1.city as city, 
   	dl1.state as state, 
   	dl1.zip as zip 


from VIEW_CtrContract join PlcXLMDPolicies XLMD on VIEW_CtrContract.CtrContractId = XLMD.PlcXLMDPolicyID join ReiTreaties                 on VIEW_CtrContract.TreatyId        = ReiTreaties.ReiTreatyId left outer join InsGroups        on VIEW_CtrContract.InsGroupId      = InsGroups.InsGroupId left outer join CodePlcStatus    on VIEW_CtrContract.Status          = CodePlcStatus.Status left outer join DirListings dl1  on VIEW_CtrContract.ProducerID      = dl1.DirListingId left outer join DirListings dl2  on VIEW_CtrContract.OfficeId        = dl2.DirListingId left outer join DirContacts      on VIEW_CtrContract.UnderwriterId   = DirContacts.DirContactId left outer join DirListings dl3  on VIEW_CtrContract.CarrierId       = dl3.DirListingId left outer join DirListings dl4  on VIEW_CtrContract.AdministratorId = dl4.DirListingId left outer join CodeSic          on InsGroups.SIC                    = CodeSic.SIC left outer join PlcXLMDSpTerms sp_trm on sp_trm.PlcXLMDPolicyId = XLMD.PlcXLMDPolicyId left outer join PlcXLMDAgTerms on PlcXLMDAgTerms.PlcXLMDPolicyId = XLMD.PlcXLMDPolicyId left outer join (    select PlcXLMDSchedules.PlcXLMDPolicyId,      SUM(CASE          WHEN SpRateSchedule in ('TS12', 'TS13', 'TS14') THEN SpCensus1          ELSE SpCensus1+SpCensus2+SpCensus3+SpCensus4        END) as Census    from PlcXLMDSchedules    join PlcXLMDSpRates on PlcXLMDSpRates.PlcXLMDScheduleId = PlcXLMDSchedules.PlcXLMDScheduleId    join PlcXLMDPolicies ON PlcXLMDPolicies.PlcXLMDPolicyId = PlcXLMDSchedules.PlcXLMDPolicyId    WHERE PlcXLMDSchedules.ScheduleType = 'PRIM'      AND PlcXLMDSpRates.EffectiveDate = PlcXLMDPolicies.EffectiveDate    group by PlcXLMDSchedules.PlcXLMDPolicyId  ) sp_rates on sp_rates.PlcXLMDPolicyId = XLMD.PlcXLMDPolicyId  LEFT OUTER JOIN (SELECT                     PlcXLMDPolicies.PlcXLMDPolicyId,                     SUM((PlcXLMDAcqExpenses.Percentage                        * DATEDIFF(MONTH, PlcXLMDAcqExpenses.EffectiveDate, DATEADD(DAY, 1, PlcXLMDAcqExpenses.ExpirationDate))                        / PlcXLMDPolicies.MonthsInContract)) as SpExpensePercent,                     SUM((PlcXLMDAcqExpenses.Amount                        * DATEDIFF(MONTH, PlcXLMDAcqExpenses.EffectiveDate, DATEADD(DAY, 1, PlcXLMDAcqExpenses.ExpirationDate))                        / PlcXLMDPolicies.MonthsInContract)) as SpExpenseAmount                  FROM PlcXLMDPolicies                  JOIN PlcXLMDAcqExpenses ON PlcXLMDAcqExpenses.PlcXLMDpolicyId = PlcXLMDPolicies.PlcXLMDPolicyId                  WHERE PlcXLMDAcqExpenses.CoverageType = 'SPEC'                    AND PlcXLMDPolicies.MonthsInContract <> 0                    AND PlcXLMDAcqExpenses.IsActive = 'Y'                  GROUP BY PlcXLMDPolicies.PlcXLMDPolicyId                 ) SpExpenses on SpExpenses.PlcXLMDPolicyId = XLMD.PlcXLMDPolicyId LEFT OUTER JOIN (SELECT                     PlcXLMDPolicies.PlcXLMDPolicyId,                     SUM((PlcXLMDAcqExpenses.Percentage                        * DATEDIFF(MONTH, PlcXLMDAcqExpenses.EffectiveDate, DATEADD(DAY, 1, PlcXLMDAcqExpenses.ExpirationDate))                        / PlcXLMDPolicies.MonthsInContract)) as AgExpensePercent,                     SUM((PlcXLMDAcqExpenses.Amount                        * DATEDIFF(MONTH, PlcXLMDAcqExpenses.EffectiveDate, DATEADD(DAY, 1, PlcXLMDAcqExpenses.ExpirationDate))                        / PlcXLMDPolicies.MonthsInContract)) as AgExpenseAmount                  FROM PlcXLMDPolicies                  JOIN PlcXLMDAcqExpenses ON PlcXLMDAcqExpenses.PlcXLMDpolicyId = PlcXLMDPolicies.PlcXLMDPolicyId                  WHERE PlcXLMDAcqExpenses.CoverageType = 'AGGR'                    AND PlcXLMDPolicies.MonthsInContract <> 0                    AND PlcXLMDAcqExpenses.IsActive = 'Y'                  GROUP BY PlcXLMDPolicies.PlcXLMDPolicyId                 ) AgExpenses on AgExpenses.PlcXLMDPolicyId = XLMD.PlcXLMDPolicyId LEFT OUTER JOIN (SELECT                     PlcXLMDPolicies.PlcXLMDPolicyId,                     ReiXLMDTreaties.SpCarrierFeePercent as SpCARFPercentage                  FROM PlcXLMDPolicies                  JOIN ReiXLMDTreaties ON ReiXLMDTreaties.ReiTreatyId = PlcXLMDPolicies.TreatyId                  WHERE NOT EXISTS (SELECT 1 FROM PlcXLMDAcqExpenses                                    WHERE PlcXLMDAcqExpenses.PlcXLMDPolicyId = PlcXLMDPolicies.PlcXLMDPolicyId                                      AND PlcXLMDAcqExpenses.AcqExpenseType = 'CARF'                                      AND PlcXLMDAcqExpenses.CoverageType   = 'SPEC')                 ) SpCARF ON SpCARF.PlcXLMDpolicyId = VIEW_CtrContract.CtrContractId LEFT OUTER JOIN (SELECT                     PlcXLMDPolicies.PlcXLMDPolicyId,                     ReiXLMDTreaties.AgCarrierFeePercent as AgCARFPercentage                  FROM PlcXLMDPolicies                  JOIN ReiXLMDTreaties ON ReiXLMDTreaties.ReiTreatyId = PlcXLMDPolicies.TreatyId                  WHERE NOT EXISTS (SELECT 1 FROM PlcXLMDAcqExpenses                                    WHERE PlcXLMDAcqExpenses.PlcXLMDPolicyId = PlcXLMDPolicies.PlcXLMDPolicyId                                      AND PlcXLMDAcqExpenses.AcqExpenseType = 'CARF'                                      AND PlcXLMDAcqExpenses.CoverageType   = 'AGGR')                 ) AgCARF ON AgCARF.PlcXLMDpolicyId = VIEW_CtrContract.CtrContractId LEFT OUTER JOIN (SELECT                     PlcXLMDPolicies.PlcXLMDPolicyId,                     ReiXLMDTreaties.PremiumTaxPercent as PremiumTaxPercent                  FROM PlcXLMDPolicies                  JOIN ReiXLMDTreaties ON ReiXLMDTreaties.ReiTreatyId = PlcXLMDPolicies.TreatyId                  WHERE NOT EXISTS (SELECT 1 FROM PlcXLMDAcqExpenses                                    WHERE PlcXLMDAcqExpenses.PlcXLMDPolicyId = PlcXLMDPolicies.PlcXLMDPolicyId                                      AND PlcXLMDAcqExpenses.AcqExpenseType = 'PTAX')                 ) PTAX ON PTAX.PlcXLMDpolicyId = VIEW_CtrContract.CtrContractId where (((VIEW_CtrContract.Status in ('BOUN', 'BIND', 'INFC')) or (VIEW_CtrContract.Status = 'SENT' and VIEW_CtrContract.StatusLevel = 'APPL')) ) and (XLMD.Status NOT IN ('DEAD', 'RESC', 'NOIS')) AND NOT ((((XLMD.Status = 'SENT') or (XLMD.Status = 'REQD')) and (XLMD.StatusLevel <> 'APPL'))) 
Group By XLMD.ProducerId,
dl1.address , 
   	dl1.city , 
   	dl1.state , 
   	dl1.zip  
 Order By paName