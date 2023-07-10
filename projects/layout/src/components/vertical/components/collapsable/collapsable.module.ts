import { NgModule } from '@angular/core';
import { VerticalNavigationCollapsableItemComponent } from './collapsable.component';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { VerticalNavigationBasicItemModule } from '../basic/basic.module';
import { VerticalNavigationDividerItemModule } from '../divider/divider.module';
import { VerticalNavigationSpacerItemModule } from '../spacer/spacer.module';
import { CommonModule } from '@angular/common';
import { VerticalNavigationGroupItemModule } from '../group/group.module';

@NgModule({
	declarations: [
		VerticalNavigationCollapsableItemComponent
	],
	imports: [
		CommonModule,
		MatIconModule,
		MatTooltipModule,
		VerticalNavigationBasicItemModule,
		VerticalNavigationDividerItemModule,
		VerticalNavigationSpacerItemModule,
		VerticalNavigationGroupItemModule
	],
	exports: [
		VerticalNavigationCollapsableItemComponent,
	]
})
export class VerticalNavigationCollapsableItemModule {
}
