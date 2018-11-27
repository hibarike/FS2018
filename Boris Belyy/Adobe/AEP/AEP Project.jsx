var myProject = app.project;
var myItem =  myProject.item(1);
var myLayer = myItem.layer(2);
var temp = myLayer.transform.position; 
if(myLayer.threeDLayer)

alert(temp);
