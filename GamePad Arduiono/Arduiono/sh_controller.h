#pragma once
#include "sh_def.h"

// Used to set pinout for controller
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
	uint8_t pin_button_6
);

// Used to get the lasted state of buttons and joystick values from controller
void sh_controller_update(
	controller_pinout_t* pinout, 
	controller_t* controller
);