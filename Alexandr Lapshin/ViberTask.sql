/*
	The program calculates average time (in minutes) that office manager spents per day.
	INPUT DATA: Text of all messeges, id's of contacts, time of first and last message.
	OUTPUT DATA: average spent minutes per day. 
*/

SELECT ROUND(sum(MessageTime)/(SELECT (max(TimeStamp)-min(TimeStamp))/1000/86400 FROM MessageInfo)/60) FROM(
  SELECT Body, ContactID, 
  CASE WHEN ContactID is 1
  THEN length(Body)/0.4
  ELSE length(Body)/0.1
  END AS MessageTime
  FROM MessageInfo
);