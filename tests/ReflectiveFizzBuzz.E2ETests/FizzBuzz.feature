Feature: FizzBuzz
    In order to verify that the FizzBuzz application returns the correct output
    As a user
    I want to see the correct output for each number

Scenario: Running FizzBuzz for numbers from 1 to 100
    Given the application is started
    When the application calculates the FizzBuzz sequence for numbers from 1 to 100
    Then I should see the correct FizzBuzz sequence in the console
