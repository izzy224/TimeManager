import { Box } from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import SingleTransaction from "./SingleTransaction";

const FinanceDataShow = ({ transactions, setSelectedTransaction }) => {
  return (
    <>
      <Box h="94vh" maxH="94vh" w="20vw" overflowY="auto">
        {transactions.map((transaction) => {
          return (
            <SingleTransaction
              transaction={transaction}
              setSelectedTransaction={setSelectedTransaction}
            />
          );
        })}
      </Box>
    </>
  );
};

export default FinanceDataShow;
