export class DateTime {
	private date: Date;

	constructor(date: Date = new Date()) {
		this.date = date;
	}

	static now(): DateTime {
		return new DateTime(new Date());
	}

	// Create a DateTime instance from a string (with optional custom format).
	static fromString(dateString: string, format?: string): DateTime {
		const date = format ? this.parseWithFormat(dateString, format) : new Date(dateString);
		return new DateTime(date);
	}

	// reate a Date instance from a string.
	static fromISO(dateString: string): DateTime {
		const dateIsoString = new Date(dateString).toISOString();
		const date = new Date(dateIsoString);
		return new DateTime(date);
	}

	// Parse a string date with a custom format.
	private static parseWithFormat(dateString: string, format: string): Date {
		// Implement custom parsing logic for your desired date format here.
		// Example: You can split the input string and extract year, month, day, etc.
		// and then create a new Date object accordingly.
		// For simplicity, we won't implement parsing with format here.
		return new Date(dateString);
	}

	// Basic getters
	getYear(): number {
		return this.date.getFullYear();
	}

	getMonth(): number {
		// JavaScript months are 0-based
		return this.date.getMonth() + 1;
	}

	getDay(): number {
		return this.date.getDate();
	}

	getHours(): number {
		return this.date.getHours();
	}

	getMinutes(): number {
		return this.date.getMinutes();
	}

	getSeconds(): number {
		return this.date.getSeconds();
	}

	// Basic setters
	setYear(year: number): void {
		this.date.setFullYear(year);
	}

	setMonth(month: number): void {
		this.date.setMonth(month - 1); // Adjust for 0-based months in JS
	}

	setDay(day: number): void {
		this.date.setDate(day);
	}

	setHours(hours: number): void {
		this.date.setHours(hours);
	}

	setMinutes(minutes: number): void {
		this.date.setMinutes(minutes);
	}

	setSeconds(seconds: number): void {
		this.date.setSeconds(seconds);
	}

	// Set various components of the DateTime instance.
	set({
		years = 0,
		months = 0,
		days = 0,
		hours = 0,
		minutes = 0,
		seconds = 0,
		weeks = 0,
	}: {
		years?: number;
		months?: number;
		days?: number;
		hours?: number;
		minutes?: number;
		seconds?: number;
		weeks?: number;
	}): DateTime {
		const newDate = new Date(this.date);
		newDate.setFullYear(this.date.getFullYear() + years);
		newDate.setMonth(this.date.getMonth() + months);
		newDate.setDate(this.date.getDate() + days + weeks * 7);
		newDate.setHours(this.date.getHours() + hours);
		newDate.setMinutes(this.date.getMinutes() + minutes);
		newDate.setSeconds(this.date.getSeconds() + seconds);
		return new DateTime(newDate);
	}

	// Add or subtract various components of the DateTime instance.
	add({
		years = 0,
		months = 0,
		days = 0,
		hours = 0,
		minutes = 0,
		seconds = 0,
		weeks = 0,
	}: {
		years?: number;
		months?: number;
		days?: number;
		hours?: number;
		minutes?: number;
		seconds?: number;
		weeks?: number;
	}): DateTime {
		const newDate = new Date(this.date);
		newDate.setFullYear(this.date.getFullYear() + years);
		newDate.setMonth(this.date.getMonth() + months);
		newDate.setDate(this.date.getDate() + days + weeks * 7);
		newDate.setHours(this.date.getHours() + hours);
		newDate.setMinutes(this.date.getMinutes() + minutes);
		newDate.setSeconds(this.date.getSeconds() + seconds);
		return new DateTime(newDate);
	}

	// Subtract various components of the DateTime instance.
	subtract({
		years = 0,
		months = 0,
		days = 0,
		hours = 0,
		minutes = 0,
		seconds = 0,
		weeks = 0,
	}: {
		years?: number;
		months?: number;
		days?: number;
		hours?: number;
		minutes?: number;
		seconds?: number;
		weeks?: number;
	}): DateTime {
		// Use the add method with negated values to subtract.
		return this.add({
			years: -years,
			months: -months,
			days: -days,
			hours: -hours,
			minutes: -minutes,
			seconds: -seconds,
			weeks: -weeks,
		});
	}

	// Add or subtract units of time
	addDays(days: number): DateTime {
		const newDate = new Date(this.date);
		newDate.setDate(newDate.getDate() + days);
		return new DateTime(newDate);
	}

	addMonths(months: number): DateTime {
		const newDate = new Date(this.date);
		newDate.setMonth(newDate.getMonth() + months);
		return new DateTime(newDate);
	}

	addYears(years: number): DateTime {
		const newDate = new Date(this.date);
		newDate.setFullYear(newDate.getFullYear() + years);
		return new DateTime(newDate);
	}

	// Date comparisons
	diffInDays(otherDate: DateTime): number {
		const timeDifference = this.date.getTime() - otherDate.date.getTime();
		return Math.floor(timeDifference / (1000 * 60 * 60 * 24));
	}

	// Utility methods
	startOf(unit: string): DateTime {
		const newDate = new Date(this.date);
		switch (unit) {
			case 'year':
				newDate.setMonth(0, 1);
				newDate.setHours(0, 0, 0, 0);
				break;
			case 'month':
				newDate.setDate(1);
				newDate.setHours(0, 0, 0, 0);
				break;
			case 'day':
				newDate.setHours(0, 0, 0, 0);
				break;
			default:
				throw new Error(`Invalid unit for startOf: ${unit}`);
		}
		return new DateTime(newDate);
	}

	// Convert to various formats
	toISO(): string {
		return this.date.toISOString();
	}

	format(pattern: string): string {
		return pattern
			.replace(/YYYY/g, this.getYear().toString())
			.replace(/MM/g, this.getMonth().toString().padStart(2, '0'))
			.replace(/DD/g, this.getDay().toString().padStart(2, '0'))
			.replace(/HH/g, this.getHours().toString().padStart(2, '0'))
			.replace(/mm/g, this.getMinutes().toString().padStart(2, '0'))
			.replace(/ss/g, this.getSeconds().toString().padStart(2, '0'));
	}

	// Return a copy of the current date as a JS Date object
	toJSDate(): Date {
		return new Date(this.date);
	}

	// Return a relative string copy of the DateTime passed in
	toRelative(fromDate: DateTime = DateTime.now()): string {
		let differenceInSeconds = (this.date.getTime() - fromDate.date.getTime()) / 1000;
		const past = differenceInSeconds < 0;
		differenceInSeconds = Math.abs(differenceInSeconds);

		let relativeTime: string;
		if (differenceInSeconds < 60) {
			relativeTime = Math.floor(differenceInSeconds) + ' seconds';
		} else if (differenceInSeconds < 3600) {
			relativeTime = Math.floor(differenceInSeconds / 60) + ' minutes';
		} else if (differenceInSeconds < 86400) {
			relativeTime = Math.floor(differenceInSeconds / 3600) + ' hours';
		} else if (differenceInSeconds < 2592000) {
			relativeTime = Math.floor(differenceInSeconds / 86400) + ' days';
		} else if (differenceInSeconds < 31536000) {
			relativeTime = Math.floor(differenceInSeconds / 2592000) + ' months';
		} else {
			relativeTime = Math.floor(differenceInSeconds / 31536000) + ' years';
		}

		return past ? relativeTime + ' ago' : 'in ' + relativeTime;
	}

	// Return the day of the week (0-6 for Sunday-Saturday)
	dayOfWeek(): number {
		return this.date.getDay();
	}

	// Return the time in milliseconds since January 1, 1970, 00:00:00 UTC
	getTime(): number {
		return this.date.getTime();
	}

	// Set the date and time by adding or subtracting a specified number of milliseconds
	addMilliseconds(milliseconds: number): DateTime {
		const newDate = new Date(this.date.getTime() + milliseconds);
		return new DateTime(newDate);
	}

	// Set the date and time by subtracting a specified number of milliseconds
	subtractMilliseconds(milliseconds: number): DateTime {
		const newDate = new Date(this.date.getTime() - milliseconds);
		return new DateTime(newDate);
	}

	// Set the date and time by adding or subtracting a specified number of seconds
	addSeconds(seconds: number): DateTime {
		return this.addMilliseconds(seconds * 1000);
	}

	// Set the date and time by subtracting a specified number of seconds
	subtractSeconds(seconds: number): DateTime {
		return this.subtractMilliseconds(seconds * 1000);
	}

	// Set the date and time by adding or subtracting a specified number of minutes
	addMinutes(minutes: number): DateTime {
		return this.addMilliseconds(minutes * 60 * 1000);
	}

	// Set the date and time by subtracting a specified number of minutes
	subtractMinutes(minutes: number): DateTime {
		return this.subtractMilliseconds(minutes * 60 * 1000);
	}

	// Set the date and time by adding or subtracting a specified number of hours
	addHours(hours: number): DateTime {
		return this.addMilliseconds(hours * 60 * 60 * 1000);
	}

	// Set the date and time by subtracting a specified number of hours
	subtractHours(hours: number): DateTime {
		return this.subtractMilliseconds(hours * 60 * 60 * 1000);
	}

	// Check if the current date is within a given range
	isWithinRange(startDate: DateTime, endDate: DateTime): boolean {
		return this.getTime() >= startDate.getTime() && this.getTime() <= endDate.getTime();
	}

	// Check if the current year is a leap year
	isLeapYear(): boolean {
		const year = this.getYear();
		return (year % 4 === 0 && year % 100 !== 0) || year % 400 === 0;
	}

	// Compare two dates and return -1 if the current date is before the other date, 
	// 1 if the current date is after the other date, or 0 if they are equal
	compare(otherDate: DateTime): number {
		if (this.isBefore(otherDate)) return -1;
		if (this.isAfter(otherDate)) return 1;
		return 0;
	}

	// Check if the current date is before another date
	isBefore(otherDate: DateTime): boolean {
		return this.getTime() < otherDate.getTime();
	}

	// Check if the current date is after another date
	isAfter(otherDate: DateTime): boolean {
		return this.getTime() > otherDate.getTime();
	}

	// Check if the current date is the same as another date (ignoring time)
	isSameDay(otherDate: DateTime): boolean {
		return this.getYear() === otherDate.getYear() &&
			this.getMonth() === otherDate.getMonth() &&
			this.getDay() === otherDate.getDay();
	}

	// Return the date of the next weekday (e.g., next Monday)
	nextWeekday(weekday: number): DateTime {
		const daysToNextWeekday = (weekday - this.dayOfWeek() + 7) % 7 || 7;
		return this.addDays(daysToNextWeekday);
	}

	// Return the date of the previous weekday (e.g., previous Monday)
	prevWeekday(weekday: number): DateTime {
		const daysToPrevWeekday = (this.dayOfWeek() - weekday + 7) % 7 || 7;
		return this.addDays(-daysToPrevWeekday);
	}
}
