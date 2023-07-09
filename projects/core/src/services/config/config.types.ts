export type Scheme = 'auto' | 'dark' | 'light';
export type Screens = { [key: string]: string };
export type Theme = 'theme-default' | string;
export type Themes = { id: string; name: string }[];

export interface OntrialConfig {
	layout: string;
	scheme: Scheme;
	screens: Screens;
	theme: Theme;
	themes: Themes;
}
