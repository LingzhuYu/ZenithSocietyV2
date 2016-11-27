import { ZenithClientSidePage } from './app.po';

describe('zenith-client-side App', function() {
  let page: ZenithClientSidePage;

  beforeEach(() => {
    page = new ZenithClientSidePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
