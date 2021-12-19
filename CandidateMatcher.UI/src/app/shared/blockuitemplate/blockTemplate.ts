import { Component } from '@angular/core';

@Component({
  styleUrls: ['./blockTemplate.css'],
  template: `<div class="block-ui-template" style="min-height: 50px">
              <img src="../../../assets/images/loading.gif" />
              <p>{{message}}</p>
            </div>`
})

export class BlockTemplate {
  message: string | undefined;
}