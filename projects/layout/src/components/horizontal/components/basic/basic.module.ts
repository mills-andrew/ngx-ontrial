import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { HorizontalNavigationBasicItemComponent } from './basic.component';
import { CommonModule } from '@angular/common';

@NgModule({
	declarations: [
		HorizontalNavigationBasicItemComponent
	],
	imports: [
		RouterModule,
		CommonModule,
		MatIconModule,
		MatMenuModule,
		MatTooltipModule
	],
	exports: [
		HorizontalNavigationBasicItemComponent,
	]
})
export class HorizontalNavigationBasicItemModule {
}
