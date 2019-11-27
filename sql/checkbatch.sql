select batbatchqueueid, loginname, inqueuedate, batchstatus from batbatchqueue join cfgsecurityusers on batbatchqueue.inqueueuserid = cfgsecurityusers.cfgsecurityuserid order by inqueuedate desc

Select

   *

FROM BatBatchTask

JOIN BatEmailTask ON BatEmailTask.BatEmailTaskId = BatBatchTask.BatBatchTaskId

WHERE ToAddress like '%hillebrand%'

order by TaskBeginDate