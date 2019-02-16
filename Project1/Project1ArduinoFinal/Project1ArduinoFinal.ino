int green   = 2;
int yellow  = 3;
int red     = 4;
int turn    = 5;
char signalRec;

void setup()
{
  pinMode(green,  OUTPUT);
  pinMode(yellow, OUTPUT);
  pinMode(red,    OUTPUT);
  pinMode(turn,   OUTPUT);
  Serial.begin(9600);

  digitalWrite(green,   LOW);
  digitalWrite(yellow,  LOW);
  digitalWrite(red,     LOW);
  digitalWrite(turn,    LOW);
}
void loop()
{

  if(Serial.available() > 0){

    signalRec = Serial.read();
    if( signalRec == 'g'){
      digitalWrite(green,   HIGH);
      digitalWrite(yellow,  LOW);
      digitalWrite(red,     LOW);
      digitalWrite(turn,    LOW);
    }
    else if( signalRec == 'y'){
      digitalWrite(green,   LOW);
      digitalWrite(yellow,  HIGH);
      digitalWrite(red,     LOW);
      digitalWrite(turn,    LOW);  
    }
    else if( signalRec == 'r'){
      digitalWrite(green,   LOW);
      digitalWrite(yellow,  LOW);
      digitalWrite(red,     HIGH);
      digitalWrite(turn,    LOW);
    }
    else if( signalRec == 't'){
      digitalWrite(green,   LOW);
      digitalWrite(yellow,  LOW);
      digitalWrite(red,     HIGH);
      digitalWrite(turn,    HIGH);
    }
    else if( signalRec == 'x'){
      digitalWrite(green,   LOW);
      digitalWrite(yellow,  LOW);
      digitalWrite(red,     LOW);
      digitalWrite(turn,    LOW);
      }
  }
}
