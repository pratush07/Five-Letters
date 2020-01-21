#pragma strict

var speed : float = 2.0;
function Start () {

}

function Update () 
{
		if(transform.position.y>8 || transform.position.y<-1 )
		speed=-speed;
	
	
	transform.Translate(0,speed*Time.deltaTime,0);
	
	
}