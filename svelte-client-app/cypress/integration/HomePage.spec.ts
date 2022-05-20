/// <reference types="cypress"/>

describe("HomePage", () => {
  beforeEach(() => {
    cy.fixture("stations").then(function (data) {
      /* register custom commands. */
      cy.getCommand("/api/v1/Stations", data);
    });
    /* go to root domain */
    cy.visit("/");
  });

  it("should display the home page and it's title", () => {
    cy.get("h1").should("contain", "Train Ticket Machine");
  });

  it("should display 'no stations found' message", () => {
    cy.get("[data-cy=no-stations]").should("be.visible");
  });

  it("should display the 5 stations when the button 'd' was clicked", () => {
    cy.get("[data-cy=letter-button]").eq(3).should("contain", "d").click();
    cy.get("[data-cy=station]").should("have.length", 5);
  });

  it("should highlight letters a, e, o, when button 'd' was clicked ", () => {
    cy.get("[data-cy=letter-button]").eq(3).should("contain", "d").click();
    cy.get("[data-cy=letter-button]")
      .eq(0)
      .should("contain", "a")
      .should("have.class", "suggested-button");
    cy.get("[data-cy=letter-button]")
      .eq(4)
      .should("contain", "e")
      .should("have.class", "suggested-button");
    cy.get("[data-cy=letter-button]")
      .eq(14)
      .should("contain", "o")
      .should("have.class", "suggested-button");
  });
});
