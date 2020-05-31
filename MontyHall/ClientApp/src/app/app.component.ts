import { Component } from '@angular/core';
import { AppService } from './app.service';
import { FormGroup, FormControl, Validators, ValidatorFn, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [AppService]
})
export class AppComponent {

  public form = new FormGroup({
    numberOfGames: new FormControl(undefined, [
      Validators.required, 
      Validators.min(1),
      Validators.max(2000000000),
      integerNumberValidator()
    ]),
    isChangeStrategy: new FormControl(false),
  })

  public winRate: number;
  public inProgress: boolean = false;

  public numberOfGamesWarning: string = undefined;
  public executeErrorMessage: string = undefined;

  constructor(private appService: AppService) {
    this.form.valueChanges
      .subscribe(() => {
        this.winRate = undefined;
        this.executeErrorMessage = undefined;
        this.numberOfGamesWarning = this.form.controls.numberOfGames.invalid
          ? 'An integer number from 1 to 2bn is expected'
          : undefined;
      })
  }

  public execute() {
    this.inProgress = true;
    this.form.disable();

    this.appService
      .execute({
        numberOfGames: this.form.controls.numberOfGames.value,
        isChangeStrategy: this.form.controls.isChangeStrategy.value
      })
      .subscribe(result => {
        this.inProgress = false;
        this.form.enable();

        if (!result) {
          this.executeErrorMessage = 'Server Error occured. Please try one more time.';
          return;
        }

        this.winRate = result.winRate;
      })
  }
}

function integerNumberValidator(): ValidatorFn {
  return (control: AbstractControl): {[key: string]: any} | null => {
    let isInteger = Math.trunc(control.value) == control.value;
    return !isInteger ? {'integerNumber': {value: control.value}} : null;
  };
}