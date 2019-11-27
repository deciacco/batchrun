select  
LogRow as row,to_timestamp(date, SUB( time, TIMESTAMP('05:00:00', 'hh:mm:ss'))) as timestamp,
cs-method as command,
cs-uri-query as command_context,
cs-bytes as bytes,
time-taken

from 
'\\IIS\logs\smtp\SMTPSVC1\ex100715.log'
where cs-username like '%outboundconnection%'
and cs-uri-query like '%ajtopa%'
order by timestamp, row asc