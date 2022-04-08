import { Flex } from "@chakra-ui/react";
import { Box } from "@chakra-ui/react";
import React, { useState, useEffect } from "react";
import Sidebar from "../Sidebar";
import FinanceDataShow from "./FinanceDataShow";
import FinanceForm from "./FinanceForm";
import FinancePieChart from "./FinancePieChart";
import FinanceBalance from "./FinanceBalance";

const Finances = () => {
  const [selectedTransaction, setSelectedTransaction] = useState(0);
  const [transactions, setTransactions] = useState([]);
  const [walletId, setWalletId] = useState(0);
  const [selectedDate, setSelectedDate] = useState(new Date());
  useEffect(() => {
    fetch("/api/finance/get", {
      method: "POST",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
      body: JSON.stringify({ date: selectedDate.toDateString(), days: 0 }),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        setWalletId(data.walletId);
        setTransactions(data.transactions);
      });
  }, [selectedDate]);
  return (
    <>
      <Flex>
        <Sidebar
          selectedDate={selectedDate}
          setSelectedDate={setSelectedDate}
          w="25vw"
        />
        <Box w="35vw">
          <FinancePieChart h="31vh" date={selectedDate} days={1} />
          <FinancePieChart h="31vh" date={selectedDate} days={7} />
        </Box>
        <Box p="20px" borderLeft="1px">
          <FinanceDataShow
            transactions={transactions}
            setSelectedTransaction={setSelectedTransaction}
            h="30vh"
            w="20vw"
          />
        </Box>
        <Box ml="20px">
          <FinanceForm
            date={selectedDate}
            walletId={walletId}
            transactions={transactions}
            setTransactions={setTransactions}
            selectedTransaction={selectedTransaction}
            w="20vw"
          />
          <FinanceBalance date={selectedDate} />
        </Box>
      </Flex>
    </>
  );
};

export default Finances;
