import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { APP_INITIALIZER, ENVIRONMENT_INITIALIZER, EnvironmentProviders, inject, Provider } from '@angular/core';
import { MATERIAL_SANITY_CHECKS } from '@angular/material/core';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { ConfigService, IOntrialConfig } from './config';
import { loadingInterceptor, LoadingService } from './loading';
import { MediaWatcherService } from './media-watcher';
import { PlatformService } from './platform';
import { SplashScreenService } from './splash-screen';
import { UtilsService } from './utils/utils.service';

/**
 * Ontrial provider
 */
export const provideOntrial = (configUrl: string, config: IOntrialConfig): Array<Provider | EnvironmentProviders> => {
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
			provide: APP_INITIALIZER,
			useFactory: (configService: ConfigService) => () => {
				configService.config = config;
				return configService.load(configUrl);
			},
			deps: [ConfigService],
			multi: true
		},

		provideHttpClient(withInterceptors([loadingInterceptor])),
		{
			provide: ENVIRONMENT_INITIALIZER,
			useValue: () => inject(LoadingService),
			multi: true,
		},
		// {
		// 	provide: ENVIRONMENT_INITIALIZER,
		// 	useValue: () => inject(MediaWatcherService),
		// 	deps: [ConfigService],
		// 	multi: true
		// },
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
