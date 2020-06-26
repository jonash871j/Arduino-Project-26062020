#pragma once

typedef signed char int8_t;
typedef unsigned char uint8_t;
typedef signed int int16_t;
typedef unsigned int uint16_t;
typedef signed long int int32_t;
typedef unsigned long int uint32_t;
typedef signed long long int int64_t;
typedef unsigned long long int uint64_t;

typedef struct controller_pinout_t
{
	uint8_t pin_joystick_x;
	uint8_t pin_joystick_y;
	uint8_t pin_joystick_button;
	uint8_t pin_button_1;
	uint8_t pin_button_2;
	uint8_t pin_button_3;
	uint8_t pin_button_4;
	uint8_t pin_button_5;
	uint8_t pin_button_6;
}controller_pinout_t;

typedef struct controller_t
{
	int16_t joystick_x;
	int16_t joystick_y;
	uint8_t buttons;
}controller_t;