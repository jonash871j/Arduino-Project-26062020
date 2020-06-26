#pragma once
#include "sh_controller.h"

#include "Arduino.h"

void sh_controller_pinout(
	controller_pinout_t* pinout,
	uint8_t pin_joystick_x,
	uint8_t pin_joystick_y,
	uint8_t pin_joystick_button,
	uint8_t pin_button_1,
	uint8_t pin_button_2,
	uint8_t pin_button_3,
	uint8_t pin_button_4,
	uint8_t pin_button_5,
	uint8_t pin_button_6)
{
	// Fills out controller pinout struct
	pinout->pin_joystick_x = pin_joystick_x;
	pinout->pin_joystick_y = pin_joystick_y;
	pinout->pin_joystick_button = pin_joystick_button;

	pinout->pin_button_1 = pin_button_1;
	pinout->pin_button_2 = pin_button_2;
	pinout->pin_button_3 = pin_button_3;
	pinout->pin_button_4 = pin_button_4;
	pinout->pin_button_5 = pin_button_5;
	pinout->pin_button_6 = pin_button_6;

	// Sets pinmode on arduiono
	pinMode(INPUT, pin_joystick_x);
	pinMode(INPUT, pin_joystick_y);
	pinMode(INPUT, pin_joystick_button);

	pinMode(INPUT, pin_button_1);
	pinMode(INPUT, pin_button_2);
	pinMode(INPUT, pin_button_3);
	pinMode(INPUT, pin_button_4);
	pinMode(INPUT, pin_button_5);
	pinMode(INPUT, pin_button_6);

}

void sh_controller_update(
	controller_pinout_t* pinout, 
	controller_t* controller)
{
	// Read joysticks analog value
	controller->joystick_x = analogRead(pinout->pin_joystick_x);
	controller->joystick_y = analogRead(pinout->pin_joystick_y);

	// Read buttons bit value
	controller->buttons = 
				   (digitalRead(pinout->pin_joystick_button) << 6) ^
						  (digitalRead(pinout->pin_button_1) << 5) ^
						  (digitalRead(pinout->pin_button_2) << 4) ^
					      (digitalRead(pinout->pin_button_3) << 3) ^ 
						  (digitalRead(pinout->pin_button_4) << 2) ^
						  (digitalRead(pinout->pin_button_5) << 1) ^
						  (digitalRead(pinout->pin_button_6)	 ) ;
}
