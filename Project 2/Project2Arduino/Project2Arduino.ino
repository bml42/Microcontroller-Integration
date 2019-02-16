//input signal from comp
char input = ' ';
int green = 2; //led used to show connection
//variables used for temp calculation
int voltage1;
float temp;
//variables used for distance calculation
int echo = 6; 
int trig = 8;
long duration = 0;
int distance = 0;
//variables used for voltage and resistance calculation
int cat = 0;
float voltage2 = 0;
float resistance = 0;
int r = 1000;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(green, OUTPUT);
  pinMode(trig, OUTPUT);
  pinMode(echo, INPUT);
  digitalWrite(green, LOW);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available() > 0){
    input = Serial.read();
    if(input == 'o'){           //communication opened
      digitalWrite(green, HIGH);
    }
    else if(input == 'x'){      //communication closed
      digitalWrite(green, LOW);
    }
    else if(input == 'd'){      //calculate distance
      digitalWrite(trig, LOW);
      delayMicroseconds(2);
      digitalWrite(trig, HIGH);
      delayMicroseconds(10);
      digitalWrite(trig, LOW);
      duration = pulseIn(echo, HIGH);
      distance = (duration * 0.034)/2;
      Serial.println(distance);   //send distance to comp
    }
    else if(input == 't'){      //calculate temperature
      voltage1 = analogRead(A0);
      temp = (float)voltage1 / 1024;
      temp = (temp * 5 - 0.5) * 100; //temp in centigrade
      Serial.println(temp);       //send temp to comp
    }
   /* else if(input == 'v'){      //calculate voltage
      cat = analogRead(A1);
      voltage2 = cat * (5/1024.0);
      resistance = r * (5 / voltage - 1);
      Serial.println(voltage);
    }*/
    else if(input == 'r'){      //calculate resistance
      cat = analogRead(A1);
      voltage2 = cat * (5/1024.0);
      resistance = r * (5 / voltage2 - 1);
      Serial.println(resistance);
    }
  }
}
