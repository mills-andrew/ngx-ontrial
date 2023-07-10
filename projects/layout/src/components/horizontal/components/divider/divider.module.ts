import { NgModule } from '@angular/core';
import { HorizontalNavigationDividerItemComponent } from './divider.component';
import { CommonModule } from '@angular/common';

@NgModule({
	declarations: [
		HorizontalNavigationDividerItemComponent
	],
	imports: [
		CommonModule
	],
	exports: [
		HorizontalNavigationDividerItemComponent,
	]
})
export class HorizontalNavigationDividerItemModule {
}
