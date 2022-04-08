import React, { useEffect, useState } from "react";
import {
  Stat,
  StatLabel,
  StatNumber,
  StatHelpText,
  StatArrow,
  StatGroup,
  Heading,
  Box,
} from "@chakra-ui/react";
const FinanceBalance = ({ date }) => {
  const [balance, setBalance] = useState({ income: 0, spendings: 0 });
  useEffect(() => {
    fetch("/api/finance/getmonthlystats", {
      method: "POST",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
      body: JSON.stringify({ date: date.toDateString() }),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        setBalance(data);
      });
  }, [date]);

  return (
    <>
      <Box>
        <Heading>Monthly stats</Heading>
        <StatGroup>
          <Stat>
            <StatLabel>Income</StatLabel>
            <StatNumber>{balance.income}MDL</StatNumber>
          </Stat>

          <Stat>
            <StatLabel>Spendings</StatLabel>
            <StatNumber>{balance.spendings}MDL</StatNumber>
          </Stat>
        </StatGroup>
      </Box>
    </>
  );
};

export default FinanceBalance;
