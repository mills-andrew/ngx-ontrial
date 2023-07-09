import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { ENVIRONMENT_INITIALIZER, EnvironmentProviders, inject, Provider } from '@angular/core';
import { MATERIAL_SANITY_CHECKS } from '@angular/material/core';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { OntrialConfig } from '../services/config';
import { ONTRIAL_CONFIG } from '../services/config/config.constants';
import { loadingInterceptor, LoadingService } from '../services/loading';
import { MediaWatcherService } from '../services/media-watcher';
import { PlatformService } from '../services/platform';
import { SplashScreenService } from '../services/splash-screen';
import { UtilsService } from '../services/utils';

/**
 * Ontrial provider
 */
export const provideOntrial = (config: OntrialConfig): Array<Provider | EnvironmentProviders> => {
	// Base providers
	const providers: Array<Provider | EnvironmentProviders> = [
		{
			// Disable 'theme' sanity check
			provide: MATERIAL_SANITY_CHECKS,
			useValue: {
				doctype: true,
				theme: false,
				version: true,
			},
		},
		{
			// Use the 'fill' appearance on Angular Material form fields by default
			provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
			useValue: {
				appearance: 'fill',
			},
		},
		{
			provide: ONTRIAL_CONFIG,
			useValue: config ?? {},
		},

		provideHttpClient(withInterceptors([loadingInterceptor])),
		{
			provide: ENVIRONMENT_INITIALIZER,
			useValue: () => inject(LoadingService),
			multi: true,
		},

		{
			provide: ENVIRONMENT_INITIALIZER,
			useValue: () => inject(MediaWatcherService),
			multi: true,
		},
		{
			provide: ENVIRONMENT_INITIALIZER,
			useValue: () => inject(PlatformService),
			multi: true,
		},
		{
			provide: ENVIRONMENT_INITIALIZER,
			useValue: () => inject(SplashScreenService),
			multi: true,
		},
		{
			provide: ENVIRONMENT_INITIALIZER,
			useValue: () => inject(UtilsService),
			multi: true,
		},
	];

	// Return the providers
	return providers;
};
