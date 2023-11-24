export interface Schema {
	/** Name of the project. */
	project: string;

	/** Whether the Angular browser animations module should be included and enabled. */
	animations: 'enabled' | 'disabled' | 'excluded';

	/** Name of pre-built theme to install. */
	theme: 'indigo-pink' | 'deeppurple-amber' | 'pink-bluegrey' | 'purple-green' | 'custom';

	/** Whether to set up global typography styles. */
	typography: boolean;
}