import { ENVIRONMENT_INITIALIZER, EnvironmentProviders, inject, Provider } from '@angular/core';
import { IconsService } from './icons.service';

const matIcons = [
	{
		namespace: '',
		url: 'assets/icons/material-twotone.svg'
	},
	{
		namespace: 'mat_outline',
		url: 'assets/icons/material-outline.svg'
	},
	{
		namespace: 'mat_solid',
		url: 'assets/icons/material-solid.svg'
	}
];

const featherIcons = [
	{
		namespace: 'feather',
		url: 'assets/icons/feather.svg'
	}
];

const heroIcons = [
	{
		namespace: 'heroicons_outline',
		url: 'assets/icons/heroicons-outline.svg'
	},
	{
		namespace: 'heroicons_solid',
		url: 'assets/icons/heroicons-solid.svg'
	},
	{
		namespace: 'heroicons_mini',
		url: 'assets/icons/heroicons-mini.svg'
	}
];

const defaultIcons = [
	...matIcons,
	...featherIcons,
	...heroIcons
];

const provideIcons = (iconSets: { namespace: string, url: string }[]): Array<Provider | EnvironmentProviders> => {
	return [
		{
			provide: ENVIRONMENT_INITIALIZER,
			useValue: () => {
				const iconsService = inject(IconsService);
				iconsService.registerIconSets(iconSets);
			},
			multi: true,
		},
	];
};


export const provideDefaultIcons = (): Array<Provider | EnvironmentProviders> => provideIcons(defaultIcons);