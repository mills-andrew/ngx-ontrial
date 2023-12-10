import { Inject, Optional } from "@angular/core";
import { DateTime } from "./date-time.handler";
import { DateAdapter as AngularDateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';

export class DateAdapter extends AngularDateAdapter<Date> {

	private dateTime: DateTime;

	constructor(@Optional() date?: Date, @Optional() @Inject(MAT_DATE_LOCALE) _dateLocale?: string) {
		super();
		this.dateTime = new DateTime(date);
	}

	// ----------------
	// BASIC GETTERS
	// ----------------

	// Return the year of the current date
	override getYear(): number {
		return this.dateTime.getYear();
	}

	// Return the month of the current date (0-based: 0 = January, 11 = December)
	override getMonth(): number {
		return this.dateTime.getMonth();
	}

	// Return the day of the month for a given date (1-31)
	override getDate(date: Date): number {
		return date.getDate();
	}

	// Return the day of the week (0 = Sunday, 6 = Saturday)
	override getDayOfWeek(): number {
		return this.dateTime.toJSDate().getDay();
	}

	// Return the day of the week as a string
	getDayOfWeekString(): string {
		const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
		return days[this.getDayOfWeek()];
	}

	// ----------------
	// DATE FORMATTING
	// ----------------

	// Return the names of months in various styles
	override getMonthNames(style: "long" | "short" | "narrow"): string[] {
		const longNames = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
		const shortNames = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
		const narrowNames = ['J', 'F', 'M', 'A', 'M', 'J', 'J', 'A', 'S', 'O', 'N', 'D'];

		switch (style) {
			case 'long': return longNames;
			case 'short': return shortNames;
			case 'narrow': return narrowNames;
		}
	}

	// Return the names of days in various styles
	override getDayOfWeekNames(style: "long" | "short" | "narrow"): string[] {
		const longNames = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
		const shortNames = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
		const narrowNames = ['S', 'M', 'T', 'W', 'T', 'F', 'S'];

		switch (style) {
			case 'long': return longNames;
			case 'short': return shortNames;
			case 'narrow': return narrowNames;
		}
	}

	// Return the names of days of the month (1-31)
	override getDateNames(): string[] {
		return Array.from({ length: 31 }, (_, i) => String(i + 1));
	}

	// Return the year of a given date as a string
	override getYearName(date: Date): string {
		return String(date.getFullYear());
	}

	// ----------------
	// DATE MANIPULATION
	// ----------------

	// Return the first day of the week (0 = Sunday, 6 = Saturday)
	override getFirstDayOfWeek(): number {
		return 0;
	}

	// Return the number of days in a given month
	override getNumDaysInMonth(date: Date): number {
		return new Date(date.getFullYear(), date.getMonth() + 1, 0).getDate();
	}

	// Create a deep copy of a given date
	override clone(date: Date): Date {
		return new Date(date);
	}

	// Create a date object with the specified year, month, and day
	override createDate(year: number, month: number, date: number): Date {
		return new Date(year, month, date);
	}

	// Return the current date and time
	override today(): Date {
		return new Date();
	}

	// Convert a string to a date based on a given format (simple implementation)
	override parse(value: any, parseFormat: any): Date | null {
		if (value instanceof Date) {
			return value;
		}
		// Could enhance this with more advanced parsing logic based on `parseFormat`
		return null;
	}

	// Format a date into a string based on a given format
	override format(date: Date, displayFormat: any): string {
		return this.dateTime.format(displayFormat as string);
	}

	// Add a specified number of years to a date
	override addCalendarYears(date: Date, years: number): Date {
		return this.dateTime.addYears(years).toJSDate();
	}

	// Add a specified number of months to a date
	override addCalendarMonths(date: Date, months: number): Date {
		return this.dateTime.addMonths(months).toJSDate();
	}

	// Add a specified number of days to a date
	override addCalendarDays(date: Date, days: number): Date {
		return this.dateTime.addDays(days).toJSDate();
	}

	// Convert a date to an ISO 8601 formatted string
	override toIso8601(date: Date): string {
		return date.toISOString();
	}

	// ----------------
	// DATE VALIDATION
	// ----------------

	// Check if an object is a valid date instance
	override isDateInstance(obj: any): boolean {
		return obj instanceof Date;
	}

	// Check if a given date is valid
	override isValid(date: Date): boolean {
		return !isNaN(date.getTime());
	}

	// Return an invalid date object (used for error handling)
	override invalid(): Date {
		return new Date(NaN);
	}
}
