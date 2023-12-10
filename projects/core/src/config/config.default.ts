import { IOntrialConfig } from "./config.types";
import { InjectionToken } from '@angular/core';

export const ONTRIAL_CONFIG = new InjectionToken<any>('ONTRIAL_APP_CONFIG');
export const defaultConfiguration: IOntrialConfig = {
	layout: 'enterprise',
	scheme: 'light',
	screens: {
		sm: '600px',
		md: '960px',
		lg: '1280px',
		xl: '1440px',
	},
	theme: 'theme-default',
	themes: [
		{
			id: 'theme-default',
			name: 'Default',
		}
	]
};