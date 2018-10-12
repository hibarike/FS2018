/* The query take all messages and calculate average spend time to write/read for each message. Sum of all spend time divide to days of using viber.
As result the query show average spend time of day in minutes.
*/
SELECT ROUND(sum(MessageTime)/(SELECT (max(TimeStamp)-min(TimeStamp))/1000/86400 FROM MessageInfo)/60,1) FROM(
	SELECT Body, ContactID, 
	CASE WHEN ContactID is 1
	THEN length(Body)/0.4
	ELSE length(Body)/0.1
	END AS MessageTime
	FROM MessageInfo
);
