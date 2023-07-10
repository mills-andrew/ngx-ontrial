import { INavigationEntity } from "./navigation.types";

export interface INavigation {
	compact: INavigationEntity[];
	default: INavigationEntity[];
	futuristic: INavigationEntity[];
	horizontal: INavigationEntity[];
}
