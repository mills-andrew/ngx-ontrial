import { IsActiveMatchOptions, Params, QueryParamsHandling } from '@angular/router';

export interface NavigationEntity {
	id?: string;
	title?: string;
	subtitle?: string;
	type:
	| 'aside'
	| 'basic'
	| 'collapsable'
	| 'divider'
	| 'group'
	| 'spacer';
	hidden?: (item: NavigationEntity) => boolean;
	active?: boolean;
	disabled?: boolean;
	tooltip?: string;
	link?: string;
	fragment?: string;
	preserveFragment?: boolean;
	queryParams?: Params | null;
	queryParamsHandling?: QueryParamsHandling | null;
	externalLink?: boolean;
	target?:
	| '_blank'
	| '_self'
	| '_parent'
	| '_top'
	| string;
	exactMatch?: boolean;
	isActiveMatchOptions?: IsActiveMatchOptions;
	function?: (item: NavigationEntity) => void;
	classes?: {
		title?: string;
		subtitle?: string;
		icon?: string;
		wrapper?: string;
	};
	icon?: string;
	badge?: {
		title?: string;
		classes?: string;
	};
	children?: NavigationEntity[];
	meta?: any;
}

export type VerticalNavigationAppearance =
	| 'default'
	| 'compact'
	| 'dense'
	| 'thin';

export type VerticalNavigationMode =
	| 'over'
	| 'side';

export type VerticalNavigationPosition =
	| 'left'
	| 'right';