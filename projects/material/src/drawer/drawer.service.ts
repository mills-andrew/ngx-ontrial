import { Injectable } from '@angular/core';
import { DrawerComponent } from './drawer.component';

@Injectable({ providedIn: 'root' })
export class DrawerService {
	private _componentRegistry: Map<string, DrawerComponent> = new Map<string, DrawerComponent>();

	/**
	 * Constructor
	 */
	constructor() {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Register drawer component
	 *
	 * @param name
	 * @param component
	 */
	registerComponent(name: string, component: DrawerComponent): void {
		this._componentRegistry.set(name, component);
	}

	/**
	 * Deregister drawer component
	 *
	 * @param name
	 */
	deregisterComponent(name: string): void {
		this._componentRegistry.delete(name);
	}

	/**
	 * Get drawer component from the registry
	 *
	 * @param name
	 */
	getComponent(name: string): DrawerComponent | undefined {
		return this._componentRegistry.get(name);
	}
}
