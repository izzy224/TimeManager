import React from "react";
import {
  Stat,
  StatLabel,
  StatNumber,
  StatHelpText,
  StatArrow,
  StatGroup,
} from "@chakra-ui/react";
const SingleTransaction = ({ transaction, setSelectedTransaction }) => {
  const handleClick = (event) => {
    console.log(transaction.transactionId);
    setSelectedTransaction(transaction.transactionId);
  };
  return (
    <>
      <Stat onClick={handleClick}>
        <StatLabel>{transaction.transactionCategory.name}</StatLabel>
        <StatNumber>{transaction.description}</StatNumber>
        <StatHelpText>
          <StatArrow
            type={
              transaction.transactionCategory.transactionTypeId == 1
                ? "increase"
                : "decrease"
            }
          ></StatArrow>
          MDL{transaction.amount}
        </StatHelpText>
      </Stat>
    </>
  );
};

export default SingleTransaction;
