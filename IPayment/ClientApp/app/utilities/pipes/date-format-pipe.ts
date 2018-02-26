
import {Pipe, PipeTransform} from '@angular/core';


@Pipe({
    name: 'dateFormatBuild'
})
export class DateFormateBuildPipe implements PipeTransform {

    transform(passedDate: string, local: string, type: string): string {
        if (passedDate) {
             const date = new Date(passedDate);
             if ( type === 'dateOnly') {
                 return date.toLocaleDateString(local)
             }else {
                 return `${date.toLocaleDateString(local)} ${date.toLocaleTimeString(local)}`;
             }
        }else {
            return '';
        }
    }
}
