import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { VerticalNavigationAsideItemComponent } from './aside.component';
import { VerticalNavigationBasicItemModule } from '../basic/basic.module';
import { VerticalNavigationCollapsableItemModule } from '../collapsable/collapsable.module';
import { VerticalNavigationDividerItemModule } from '../divider/divider.module';
import { VerticalNavigationSpacerItemModule } from '../spacer/spacer.module';
import { VerticalNavigationGroupItemModule } from '../group/group.module';

@NgModule({
	declarations: [
		VerticalNavigationAsideItemComponent
	],
	imports: [
		CommonModule,
		MatIconModule,
		MatTooltipModule,
		VerticalNavigationBasicItemModule,
		VerticalNavigationCollapsableItemModule,
		VerticalNavigationDividerItemModule,
		VerticalNavigationSpacerItemModule,
		VerticalNavigationGroupItemModule
	],
	exports: [
		VerticalNavigationAsideItemComponent,
	]
})
export class VerticalNavigationAsideItemModule {
}
